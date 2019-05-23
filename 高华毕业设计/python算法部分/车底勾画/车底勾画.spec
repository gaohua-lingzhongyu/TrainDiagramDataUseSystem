# -*- mode: python -*-

block_cipher = None


a = Analysis(['C:\\Users\\ÎÒÊÇÙ¡Àöæ«\\AppData\\Local\\Programs\\Python\\Python36\\Lib\\site-packages\\PyInstaller\\³µµ×¹´»­\\³µµ×¹´»­.py'],
             pathex=['C:\\Users\\ÎÒÊÇÙ¡Àöæ«\\AppData\\Local\\Programs\\Python\\Python36\\Lib\\site-packages\\PyInstaller\\³µµ×¹´»­'],
             binaries=[],
             datas=[],
             hiddenimports=[],
             hookspath=[],
             runtime_hooks=[],
             excludes=[],
             win_no_prefer_redirects=False,
             win_private_assemblies=False,
             cipher=block_cipher)
pyz = PYZ(a.pure, a.zipped_data,
             cipher=block_cipher)
exe = EXE(pyz,
          a.scripts,
          a.binaries,
          a.zipfiles,
          a.datas,
          name='³µµ×¹´»­',
          debug=False,
          strip=False,
          upx=True,
          runtime_tmpdir=None,
          console=True )
